namespace FinalProject.Models;

public class profile
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
}
public class Account : profile
{

    public string Email { get; set; }

}
