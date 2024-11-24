using System.Collections.ObjectModel;

namespace DAL.Models;

public class Category
{
public int Id { get; set; }
public string Name { get; set; }

//Navigation Props:
public Collection<Product> Products { get; set; }

}

