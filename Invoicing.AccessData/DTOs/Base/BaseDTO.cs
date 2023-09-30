namespace Invoicing.AccessData.DTOs.Base
{
    public abstract class BaseDTO
    {
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime ModificationDate { get; set; }
        public string ModificationUser { get; set; }
    }
}
