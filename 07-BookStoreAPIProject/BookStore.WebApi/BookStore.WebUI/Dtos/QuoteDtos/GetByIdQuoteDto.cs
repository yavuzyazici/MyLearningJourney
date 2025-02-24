namespace BookStore.WebUI.Dtos.QuoteDtos
{
    public class GetByIdQuoteDto
    {
        public int QuoteId { get; set; }
        public string QuoteText { get; set; }
        public string QuoteAuthor { get; set; }
    }
}
