namespace win10Core.Business.Model
{
    public class LogInfo
    {
        /// <summary>
        /// LogInfoID
        /// </summary>
        public int LogInfoId { get; set; }
        
        /// <summary>
        /// Method Name from Log
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Message from Log
        /// </summary>
        public string Message { get; set; }
    }
}
