﻿using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    public class CoursePageViewModel
    {
        public required ModelListPage Page { get; set; }
        public Course Model { get; private set; }
        public bool IsEditMode { get; set; } = false;
        public bool IsAddMode { get; set; } = false;

        public CoursePageViewModel(Course course)
        {
            Model = IModel.Clone(course);
        }

        public IEnumerable<Module> Modules => IsAddMode
            ? ModuleService.Instance.List()
            : ModuleService.Instance.FromSchoolId(Model.Module.School.Id);

        public IEnumerable<Room> Rooms => RoomService.Instance.FromSchoolId(Model.Module.School.Id);
    }
}
