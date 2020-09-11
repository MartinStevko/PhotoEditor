using System;
using System.Collections.Generic;

namespace PhotoEditor
{
    /// <summary>
    /// Pipiline of color mixer delegates for color calculation
    /// </summary>
    public class ColorMixerPipeline
    {
        /// <summary>
        /// List of delegates for pixel color calculation
        /// </summary>
        private List<ColorMixer> jobs;

        /// <summary>
        /// Initialize pipeline with defaults
        /// </summary>
        public ColorMixerPipeline()
        {
            jobs = new List<ColorMixer>();
        }

        /// <summary>
        /// Adds color mixer to the pipeline
        /// </summary>
        /// <param name="job">Color mixer function</param>
        public void Add(ColorMixer job)
        {
            jobs.Add(job);
        }

        /// <summary>
        /// Pipeline runner - executes jobs in the color mixer list in order 
        /// using output of some color mixer as input to another color mixer
        /// </summary>
        /// <param name="r">Red value in RGB format</param>
        /// <param name="g">Green value in RGB format</param>
        /// <param name="b">Blue value in RGB format</param>
        /// <returns>Tuple of (red, green, blue) values of new color in RGB format</returns>
        public Tuple<byte, byte, byte> Run(byte r, byte g, byte b)
        {
            Tuple<byte, byte, byte> response = null;
            if (jobs.Count > 0)
            {
                foreach (ColorMixer job in jobs)
                {
                    if (response == null)
                    {
                        response = job(r, g, b);
                    }
                    else
                    {
                        response = job(response.Item1, response.Item2, response.Item3);
                    }
                }
            } 
            else
            {
                response = new Tuple<byte, byte, byte>(r, g, b);
            }
            
            return response;
        }
    }
}
