using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Chapter_7___Object_Oriented_Design
{
    /// <summary>
    /// Call Center: Imagine you have a call center with three levels of employees: respondent, manager,
    /// and director.An incoming telephone call must be first allocated to a respondent who is free. If the
    /// respondent can't handle the call, he or she must escalate the call to a manager. If the manager is not
    /// free or not able to handle it, then the call should be escalated to a director. Design the classes and
    /// data structures for this problem.Implement a method dispatchCall() which assigns a call to
    /// the first available employee.
    /// </summary>
    class CallCenter
    {
        private const int NUMBER_OF_TIERS = 3;
        private readonly Queue<Employee>[] _callHandlerTiers = new Queue<Employee>[NUMBER_OF_TIERS];
        private readonly Dictionary<Type, int> _employeeEscalationRankDict;

        public CallCenter(List<Employee> employees)
        {
            _employeeEscalationRankDict = new Dictionary<Type, int>
                { { typeof(Respondent), 0},
                  { typeof(Manager),    1},
                  { typeof(Director),   2} };

            for (int i = 0; i < NUMBER_OF_TIERS; i++)
            {
                _callHandlerTiers[i] = new Queue<Employee>();
            }

            foreach (Employee employee in employees)
            {
                int rankIndex = GetEmployeeRankIndex(employee);
                _callHandlerTiers[rankIndex].Enqueue(employee);
            }
        }

        private int GetEmployeeRankIndex(Employee employee)
        {
            foreach (Type employeeType in _employeeEscalationRankDict.Keys)
            {
                if (employee.GetType() == employeeType)
                {
                    int index = _employeeEscalationRankDict[employee.GetType()];
                    return index;
                }
            }

            throw new Exception("Unsupported Employee type found.");
        }

        public void DispatchCall(Call call)
        {
            for (int i = 0; i < NUMBER_OF_TIERS; i++)
            {
                if (_callHandlerTiers[i].Count > 0)
                {
                    Employee employeeSelectedToHandle = _callHandlerTiers[i].Dequeue();
                    employeeSelectedToHandle.HandleCall(call);
                    return;
                }
            }

            throw new Exception("Unable to handle the volume of calls.");
        }

        public void AddEmployeeBackToQueue(Employee employee)
        {
            int rankIndex = GetEmployeeRankIndex(employee);
            _callHandlerTiers[rankIndex].Enqueue(employee);
        }
    }

    public abstract class Employee
    {
        private string _name;

        public void HandleCall(Call call)
        {
            call.IsCompleted = true;
        }
    }

    public class Respondent : Employee { }

    public class Manager : Employee { }

    public class Director : Employee { }

    public class Call
    {
        private string _callerPhoneNumber;
        private string _callerName;
        public bool IsCompleted;

        public Call(string name, string phoneNumber)
        {
            this._callerName = name;
            this._callerPhoneNumber = phoneNumber;
            IsCompleted = false;
        }
    }

    public class _7_2_CallCenterTests
    {
        [Test]
        public void _7_1_CallCenter_WithManagableIncomingCalls_ShouldEscalateCallsSuccessfully()
        {
            //Arrange
            List<Employee> employees = new List<Employee>();
            Employee respondent = new Respondent();
            Employee manager = new Manager();
            Employee director = new Director();

            employees.Add(respondent);
            employees.Add(manager);
            employees.Add(director);

            List<Call> incomingCalls = new List<Call>();
            Call call1 = new Call("Billy", "123-1232");
            Call call2 = new Call("Bob", "123-1233");
            Call call3 = new Call("Jim", "123-1234");

            incomingCalls.Add(call1);
            incomingCalls.Add(call2);
            incomingCalls.Add(call3);

            //Act
            CallCenter testCallCenter = new CallCenter(employees);

            foreach (Call call in incomingCalls)
            {
                testCallCenter.DispatchCall(call);
            }

            //Assert
            foreach (Call call in incomingCalls)
            {
                Assert.AreEqual(true, call.IsCompleted);
            }
        }

        [Test]
        public void _7_1_CallCenter_WithTooManyCall_ShouldThrowException()
        {
            //Arrange
            List<Employee> employees = new List<Employee>();
            Employee respondent = new Respondent();
            employees.Add(respondent);

            Call call1 = new Call("Billy", "123-1232");
            Call call2 = new Call("Bob", "123-1233");

            //Act
            CallCenter testCallCenter = new CallCenter(employees);
            testCallCenter.DispatchCall(call1);

            //Assert
            Assert.Throws<Exception>(() => testCallCenter.DispatchCall(call2));
        }

        [Test]
        public void _7_1_CallCenter_WithTimeBetweenCalls_ShouldHandleCallsSuccessfully()
        {
            //Arrange
            List<Employee> employees = new List<Employee>();
            Employee respondent = new Respondent();
            employees.Add(respondent);

            Call call1 = new Call("Billy", "123-1232");
            Call call2 = new Call("Bob", "123-1233");

            //Act
            CallCenter testCallCenter = new CallCenter(employees);
            testCallCenter.DispatchCall(call1);

            //The call is complete and the employee can take another call
            testCallCenter.AddEmployeeBackToQueue(respondent);

            testCallCenter.DispatchCall(call2);

            //Assert
            Assert.AreEqual(true, call1.IsCompleted);
            Assert.AreEqual(true, call2.IsCompleted);
        }
    }
}
