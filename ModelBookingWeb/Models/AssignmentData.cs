using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ModelBooking.Utilities;
using ModelBookingWPF.Models;

namespace ModelBookingWeb.Models
{
    public class AssignmentData
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AssignmentData(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Models.LoadModels();
            Assignments.LoadAssignments();
        }
        public ObservableCollection<Assignment> Assignments { get; } = new ObservableCollection<Assignment>();
        public ObservableCollection<Model> Models { get; } = new ObservableCollection<Model>();

        public Model MyData
        {
            get
            {
                Guid guid;
                var modelID = Guid.TryParse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value, out guid) ? guid : Guid.Empty;
                return Models.FirstOrDefault(x => x.id == modelID);
            }
        }

        public List<Assignment> MyAssignments
        {
            get
            {
                var model = MyData;
                var assignments = model != null ? Assignments.Where(x => model.Assignments.Contains(x.id)).ToList() : new List<Assignment>();
                return assignments;
            }
        }

        public List<Assignment> UpcommingAssignments
        {
            get { return MyAssignments.Where(x => x.StartDate > DateTime.Today).ToList(); }
        }


        public List<Assignment> PreviousAssignments
        {
            get { return MyAssignments.Where(x => x.StartDate <= DateTime.Today).ToList(); }
        }


        public void AddExpence(Guid assignmentId, DateTime date, string text, double amount)
        {
            var model = MyData;
            model.Expenses.Add(new Expense()
            {
                AssignmentId = assignmentId,
                date = date,
                text = text,
                amount = amount
            });
            Models.SaveModels();
        }
    }
}
