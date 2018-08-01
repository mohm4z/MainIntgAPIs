namespace MainIntgAPIs
{
    internal class ValidationFault
    {
        public bool Result { get; internal set; }
        public string Message { get; internal set; }
        public string Description { get; internal set; }
    }
}