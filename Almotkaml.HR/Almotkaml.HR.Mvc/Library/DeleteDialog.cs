namespace Almotkaml.HR.Mvc.Library
{
    public class DeleteDialog
    {
        public DeleteDialog()
        {
            Name = "delete";
            Value = "Id";
        }
        public DeleteDialog(object value, string fieldName)
        {
            Name = fieldName;
            Value = value;
        }

        public DeleteDialog(string propertyName, object value)
        {
            Name = "delete" + propertyName;
            Value = value;
        }
        public string Name { get; private set; }
        public object Value { get; private set; }
    }
}