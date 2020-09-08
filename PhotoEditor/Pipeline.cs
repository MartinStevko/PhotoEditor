using System;
using System.Collections.Generic;

namespace PhotoEditor
{
    public class ColorMixerPipeline
    {
        private List<ColorMixer> jobs;

        public ColorMixerPipeline()
        {
            jobs = new List<ColorMixer>();
        }

        public void Add(ColorMixer job)
        {
            jobs.Add(job);
        }

        public Tuple<byte, byte, byte> Run(byte r, byte g, byte b)
        {
            Tuple<byte, byte, byte> response = null;
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
            return response;
        }
    }
}