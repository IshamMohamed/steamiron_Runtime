using Microsoft.Azure.Mobile.Server;

namespace steamironService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }

        public string Dummy { get; set; }

        public bool dumBool { get; set; }
    }
}