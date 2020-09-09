using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using System.IO;

namespace PhotoEditor
{
    /// <summary>
    /// Static class for LUT file methods
    /// </summary>
    public static class LookUpTable
    {
        /// <summary>
        /// Lists all imported LUT files
        /// </summary>
        /// <returns>Array of LUT files names</returns>
        public static string[] List()
        {
            return Properties.Resources.luts.Split(',');
        }

        /// <summary>
        /// Reads LUT from file to memory
        /// </summary>
        /// <param name="name">LUT filename</param>
        /// <returns>Tuple of LUT size and color 3D map</returns>
        public static Tuple<int, Tuple<byte, byte, byte>[,,]> Read(string name)
        {
            string[] lines = Regex.Split(
                Encoding.Default.GetString((byte[])Properties.Resources.ResourceManager.GetObject(name)),
                "\r\n|\r|\n"
            );

            int size = int.Parse(lines[1].Split(' ')[1]);
            Tuple<byte, byte, byte>[, ,] map = new Tuple<byte, byte, byte>[size, size, size];
            int pointer = 3;
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    for (int k = 0; k < size; ++k)
                    {
                        string[] c = lines[pointer].Split(' ');
                        map[k, j, i] = new Tuple<byte, byte, byte>(
                            (byte)(float.Parse(c[0], CultureInfo.InvariantCulture.NumberFormat) * 255),
                            (byte)(float.Parse(c[1], CultureInfo.InvariantCulture.NumberFormat) * 255),
                            (byte)(float.Parse(c[2], CultureInfo.InvariantCulture.NumberFormat) * 255)
                        );
                        ++pointer;
                    }
                }
            }

            return new Tuple<int, Tuple<byte, byte, byte>[,,]>(size, map);
        }

        /// <summary>
        /// Creates color map based on chanes made
        /// </summary>
        /// <param name="tasks">Task list</param>
        /// <returns>Tuple of LUT size and color map</returns>
        public static Tuple<int, Tuple<byte, byte, byte>[,,]> Export(Stack<ImageTask> tasks)
        {
            ColorMixerPipeline pipeline = new ColorMixerPipeline();
            Stack<ImageTask> changes = new Stack<ImageTask>(tasks);
            while (changes.Count > 0) 
            {
                ImageTask imgTask = changes.Pop();
                if ((imgTask.taskType != ImageModification.FlipHorizontally) && (imgTask.taskType != ImageModification.FlipVertically))
                {
                    ColorMixer colorMixer = ((ColorTask)imgTask).ColorMixer;
                    pipeline.Add(colorMixer);
                }
            }

            Tuple<byte, byte, byte>[,,] colors = new Tuple<byte, byte, byte>[32, 32, 32];
            for (int i = 0; i < 32; ++i)
            {
                double b = i / 31.0;
                for (int j = 0; j < 32; ++j)
                {
                    double g = j / 31.0;
                    for (int k = 0; k < 32; ++k)
                    {
                        double r = k / 31.0;
                        colors[i, j, k] = pipeline.Run((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
                    }
                }
            }

            return new Tuple<int, Tuple<byte, byte, byte>[,,]>(32, colors);
        }

        /// <summary>
        /// Writes memory stream to LUT file
        /// </summary>
        /// <param name="filename">Filename of LUT file</param>
        /// <param name="tasks">List of tasks LUT should be generated from</param>
        public static void Write(string filename, Stack<ImageTask> tasks)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine("TITLE ");
                sw.WriteLine("LUT_3D_SIZE 32");
                sw.WriteLine();

                Tuple<int, Tuple<byte, byte, byte>[,,]> colors = Export(tasks);
                for (int i = 0; i < 32; ++i)
                {
                    double b = i / 31;
                    for (int j = 0; j < 32; ++j)
                    {
                        double g = j / 31;
                        for (int k = 0; k < 32; ++k)
                        {
                            Tuple<byte, byte, byte> color = colors.Item2[i, j, k];
                            sw.WriteLine(
                                (color.Item1 / 255.0).ToString(CultureInfo.InvariantCulture) + " " + 
                                (color.Item2 / 255.0).ToString(CultureInfo.InvariantCulture) + " " + 
                                (color.Item3 / 255.0).ToString(CultureInfo.InvariantCulture)
                            );
                        }
                    }
                }
            }
        }
    }
}
