namespace UserModule
{
    public class Location
    {
        /// <summary>
        /// get /set building name
        /// </summary>
        public string Building { get; set; }
        /// <summary>
        /// get /set floor number
        /// </summary>
        public string Floor { get; set; }
        /// <summary>
        /// get / set department 
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// get /set if camera is active
        /// </summary>
        public bool IsCamActive { get; set; }
    }
}