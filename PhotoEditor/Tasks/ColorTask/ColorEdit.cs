namespace PhotoEditor.Tasks
{
    /// <summary>
    /// Common ancestor for sauration/brightness/clarity changes
    /// </summary>
    public abstract class ColorEdit : ColorTask
    {
        /// <summary>
        /// Level of saturation/brightness/clarity
        /// </summary>
        public int value;

        /// <summary>
        /// Constructor caller of base constructor
        /// Inicialize also edit value
        /// </summary>
        /// <param name="mod">One of provided image modifications</param>
        /// <param name="imageSet">Pointer to image set from engine</param>
        /// <param name="value">Particular edit level</param>
        public ColorEdit(ImageModification mod, ImageSet imageSet, int value) : base(mod, imageSet)
        {
            this.value = value;
        }
    }
}
