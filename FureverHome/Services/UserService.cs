﻿using FureverHome.Models;
using FureverHome.Repositories;
using System;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FureverHome.Services
{
    internal class UserService : IUserService
    {
        public static User? LoggedInUser { get; private set; }
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public UserService(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Add(string? firstName, string? lastName, string? username, string? password, Gender gender, string? phone,
            string? adress)
        {
            if (_accountRepository.GetAll().Any(account => account.UserName.Equals(username)))
                throw new InvalidInputException("Username already exists");

            _accountRepository.Add();
            _userRepository.Add(new Student(firstName, lastName, username, password, gender, phone, education));
            else if (languages is not null)
            {
                List<Language> languagesFromDB = new List<Language>();
                foreach (Language language in languages)
                {
                    languagesFromDB.Add(_languageService.GetLanguage(language.Name, language.Level));
                }
                _userRepository.Add(new Teacher(firstName, lastName, username, password, gender, phone, languagesFromDB));
            }
            else
                throw new InvalidInputException("Invalid input");
        }

        public void Update(int id, string firstName, string lastName, string password, Gender gender, string phone,
            , int penaltyPoints = -1)
        {
            User user = _userRepository.GetById(id) ?? throw new InvalidInputException("User doesn't exist");

            if (user is Student studentCheck && (studentCheck.AppliedCourses.Any() || studentCheck.ActiveCourseId != null ||
                                                 studentCheck.AppliedExams.Any()))
                throw new InvalidInputException(
                    "You cannot change your information if you have applied to, or enrolled in any courses");

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Password = password;
            user.Gender = gender;
            user.Phone = phone;

            if (user is Student)
            {
                ((Student)user).PenaltyPoints = penaltyPoints != -1 ? penaltyPoints : ((Student)user).PenaltyPoints;
                ((Student)user).Education = education;
            }

            _userRepository.Update(user);

            if (LoggedInUser?.Id == id)
                LoggedInUser = user;
        }

        public void Delete(int id)
        {
            User user = _userRepository.GetById(id) ?? throw new InvalidOperationException("User doesn't exist");

            switch (user)
            {
                case Student student:
                    DeleteStudent(student);
                    break;
                case Teacher teacher:
                    DeleteTeacher(teacher);
                    break;
            }

            _userRepository.Delete(id);

            if (LoggedInUser?.Id == id)
                LoggedInUser = null;
        }

        public User? Login(string email, string password)
        {
            User? user = _userRepository.GetAll()
                .FirstOrDefault(user => !user.Deleted && user.Username.Equals(email) && user.Password.Equals(password));
            LoggedInUser = user;
            return user;
        }

        public void Logout()
        {
            if (LoggedInUser == null)
                throw new InvalidInputException("Already logged out.");

            LoggedInUser = null;
        }

        private void DeleteStudent(Student student)
        {
            foreach (var course in student.AppliedCourses.Select(courseId =>
                         _courseRepository.GetById(courseId) ??
                         throw new InvalidOperationException("Course doesn't exist")))
            {
                course.RemoveStudent(student.Id);
                _courseRepository.Update(course);
            }

            foreach (Exam exam in _examService.GetAll())
            {
                // remove student from exams only ih exam was not held
                if (exam.StudentIds.Contains(student.Id) && exam.TeacherGraded != true)
                {
                    exam.StudentIds.Remove(student.Id);
                    _examRepository.Update(exam);
                }
            }
            if (student.ActiveCourseId is null) return;

            Course enrolledCourse = _courseRepository.GetById(student.ActiveCourseId!.Value) ??
                                    throw new InvalidOperationException("Course doesn't exist");
            enrolledCourse.RemoveStudent(student.Id);
            _courseRepository.Update(enrolledCourse);
        }

        private void DeleteTeacher(Teacher teacher)
        {
            foreach (Course course in _courseRepository.GetAll())
            {
                if (course.TeacherId == teacher.Id && (DateTime.Now - course.StartDate.ToDateTime(TimeOnly.MinValue)).TotalDays >= 0 && course.Confirmed && !course.IsFinished)
                {
                    throw new InvalidInputException("You cannot delete this teacher while they are on an active course.");
                }

                if (course.TeacherId == teacher.Id && course.StartDate.ToDateTime(TimeOnly.MinValue) > DateTime.Today)
                {
                    // creator of the course is either teacher or director
                    switch (course.CreatorId.HasValue ? _userRepository.GetById(course.CreatorId.Value) : null)
                    {
                        case Teacher:
                            _courseService.Delete(course.Id);
                            break;
                        case null:
                        case Director:
                            course.TeacherId = null;
                            _courseRepository.Update(course);
                            break;
                    }
                }
            }
            foreach (Exam exam in _examRepository.GetAll())
            {
                // if exam is in the future delete it
                if (exam.Date.ToDateTime(TimeOnly.MinValue) > DateTime.Today && exam.TeacherId == teacher.Id)
                {
                    _examService.Delete(exam.Id);
                }
            }
            _userRepository.Delete(teacher.Id);
        }

    }
