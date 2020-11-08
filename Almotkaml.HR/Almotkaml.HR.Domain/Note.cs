namespace Almotkaml.HR.Domain
{
    public class Note
    {
        public static Note New(string name)
        {
            Check.NotEmpty(name, nameof(name));

            var note = new Note()
            {
                Name = name,
            };


            return note;
        }
        private Note()
        {

        }
        public int NoteId { get; private set; }
        public string Name { get; private set; }
        public void Modify(string name)
        {
            Check.NotEmpty(name, nameof(name));

            Name = name;

        }
    }
}