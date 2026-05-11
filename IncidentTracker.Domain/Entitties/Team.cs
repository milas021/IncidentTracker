using IncidentTracker.Domain.Exceptions;

namespace IncidentTracker.Domain.Entitties;
public class Team : Entity {
    private Team() { }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();

    public Team(string name, string? description) {
        validateName(name);
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public void AddMember(User user) {
        Users.Add(user);
    }

    public void SetMembers(IEnumerable<User> users) {
        Users.Clear();
        foreach (var user in users) {
            Users.Add(user);
        }
    }

    private void validateName(string name) {
        if (string.IsNullOrEmpty(name)) {
            throw new AppException("Please Enter Valid Name");
        }
    }


}

