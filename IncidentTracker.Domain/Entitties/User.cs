using IncidentTracker.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace IncidentTracker.Domain.Entitties;
public class User : Entity {
    private User() { }
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string? Email { get; private set; }
    public string Mobile { get; private set; }
    public Guid? TeamId { get; private set; }
    public Team Team { get; private set; }

    public User(string fullNAme, string mobile) {
        checkMobileValidity(mobile);
        checkNameValidity(fullNAme);

        Id = Guid.NewGuid();
        FullName = fullNAme;
        Mobile = mobile;
    }

    public User SetEmail(string? email) {
        if (email is null) {
            return this;
        }

        var regex = "^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$";

        if (!Regex.IsMatch(email, regex)) {
            throw new AppException("Please Enter Valid Email");
        }

        Email = email;
        return this;
    }

    public User SetTeamId(Guid? teamId) {
        TeamId = teamId;
        return this;
    }

    private void checkMobileValidity(string mobile) {
        string pattern = @"^(\+989|989|09)\d{9}$";
        if (!Regex.IsMatch(mobile, pattern)) {
            throw new AppException("Please Enter Valid Mobile");
        }
    }

    private void checkNameValidity(string name) {
        if (string.IsNullOrEmpty(name)) {
            throw new AppException("Please Enter Name");
        }
    }


}

