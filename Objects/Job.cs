using System.Collections.Generic;
using JobBoard.Objects;
using System;

namespace JobBoard.Objects
{
  public class Job
  {
    private int _id;
    private string _title;
    private string _description;
    private Contact _contactInfo;
    private static List<Job> _instances = new List<Job> {};

    public Job (string title, string description, Contact contactInfo)
    {
      _id = _instances.Count;
      _title = title;
      _description = description;
      _contactInfo = contactInfo;

      _instances.Add(this);
    }

    public int GetId()
    {
      return _id;
    }
    public string GetTitle()
    {
      return _title;
    }
    public void SetTitle(string newTitle)
    {
      _title = newTitle;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public Contact GetContactInfo()
    {
      return _contactInfo;
    }
    public void SetContactInfo(Contact newContactInfo)
    {
      _contactInfo = newContactInfo;
    }

    public static List<Job> GetAll()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(this);
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Job SearchJobs(int searchId)
    {
      return _instances[searchId];
    }
  }
}
