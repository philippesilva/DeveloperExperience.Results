namespace Dev.Results
{
    public struct ValidationError
    {
        public string Identifier { get; set; }
        public string ErrorMessage { get; set; }

        public ValidationError(string identifier, string errorMessage)
        {
            Identifier = identifier;
            ErrorMessage = errorMessage;
        }
    }
}
