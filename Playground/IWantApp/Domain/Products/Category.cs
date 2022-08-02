using Flunt.Validations;

namespace IWantApp.Domain.Products
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public bool Active { get; private set; } = true;
        public Category(string name, string createdBy, string editedBy)
        {
            AddNotifications(new Contract<Category>()
                            .IsNotNullOrEmpty(name, "Name")
                            .IsNotNullOrEmpty(createdBy, "CreatedBy")
                            .IsNotNullOrEmpty(editedBy, "EditedBy"));

            Name = name;
            Active = true;
            EditedBy = editedBy;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
            EditedOn = DateTime.Now;
        }

        public void EditInfo(string name, bool active)
        {
            AddNotifications(new Contract<Category>()
                .IsNotNullOrEmpty(name, "Name")
                .IsNotNull(active, "Active"));

            Name = name;
            Active = true;
        }
    }
}
