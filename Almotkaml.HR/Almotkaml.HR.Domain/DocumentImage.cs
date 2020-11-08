namespace Almotkaml.HR.Domain
{
    public class DocumentImage
    {

        public static DocumentImage New(int documentId, byte[] image)
        {
            Check.MoreThanZero(documentId, nameof(documentId));
            Check.NotNull(image, nameof(image));

            return new DocumentImage()
            {
                DocumentId = documentId,
                Image = image,
            };
        }
        public static DocumentImage New(Document document, byte[] image)
        {
            Check.NotNull(document, nameof(document));
            Check.NotNull(image, nameof(image));

            return new DocumentImage()
            {
                DocumentId = document.DocumentId,
                Document = document,
                Image = image,
            };
        }

        private DocumentImage() { }
        public int DocumentImageId { get; private set; }
        public int DocumentId { get; private set; }
        public Document Document { get; private set; }
        public byte[] Image { get; private set; }
    }
}