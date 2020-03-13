using System;
using SQLite;
using Xamarin.Forms;


public class Company
{
    [PrimaryKey]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public String DateTime { get; set; }

    public override string ToString()
    {
        return this.Name + "-----------" + this.Address + "hrs" + "-----------" + this.DateTime ;
    }
}
    


