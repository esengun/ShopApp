namespace ShopApp.WebUI.Models
{
	public class AlertMessage
	{
		public string MessageText { get; set; }
		public string MessageType { get; set; }

        public AlertMessage(string text, string type)
        {
            this.MessageText = text;
            this.MessageType = type;
        }
    }
}
