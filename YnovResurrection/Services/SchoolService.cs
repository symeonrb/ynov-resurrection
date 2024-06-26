﻿using YnovResurrection.Models;

namespace YnovResurrection.Services;

public class SchoolService : AService
{
    private SchoolService()
    {
        CreateSchool(name: "MusicHouse");
        CreateSchool(name: "NobodyNovy"); // unused school
    }

    public static SchoolService Instance { get; } = new();

    private readonly List<School> _fakeData = [];

    public School CreateSchool(string name)
    {
        var school = new School
        {
            Name = name,
            Admins = [],
            Teachers = [],
            Buildings = []
        };
        ApplyId(school);

        _fakeData.Add(school);
        // TODO : replace by this
        // _appDb.Buildings.Add(school);
        // Flush();

        return school;
    }

    public void DeleteSchool(School school) => _fakeData.Remove(school);

    public ICollection<School> List()
    {
        return _fakeData; // TODO : _appDb.Schools.ToList();
    }

    public void UpdateSchool(School school)
    {
        var index = _fakeData.FindIndex(b => b.Id == school.Id);
        if (index == -1) return;
        _fakeData[index] = school;
    }
    
}
