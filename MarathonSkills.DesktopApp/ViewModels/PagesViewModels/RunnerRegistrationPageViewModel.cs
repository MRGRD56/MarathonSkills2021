﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using MarathonSkills.Context;
using MarathonSkills.DesktopApp.Extensions;
using MarathonSkills.DesktopApp.Other;
using MarathonSkills.DesktopApp.Views.Pages;
using MarathonSkills.Model.DbModels;
using MarathonSkills.Shared;

namespace MarathonSkills.DesktopApp.ViewModels.PagesViewModels
{
    public class RunnerRegistrationPageViewModel : BaseViewModel
    {
        public Runner NewRunner { get; } = new() { User = new User() };

        public ObservableCollection<Gender> Genders { get; } = new();

        public ObservableCollection<Country> Countries { get; } = new();

        public Command RegistrationCommand => new(o =>
        {
            var page = (RunnerRegistrationPage) o;

            var password1 = page.PasswordBox1.Password;
            var password2 = page.PasswordBox2.Password;

            if (string.IsNullOrWhiteSpace(password1) ||
                string.IsNullOrWhiteSpace(NewRunner.User.Email) ||
                string.IsNullOrWhiteSpace(NewRunner.User.FirstName) ||
                string.IsNullOrWhiteSpace(NewRunner.User.LastName) ||
                NewRunner.Gender == null ||
                NewRunner.DateOfBirth == null ||
                NewRunner.Country == null)
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Validation.IsValidEmail(NewRunner.Email))
            {
                MessageBox.Show("Некорректный email-адрес!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (password1 != password2)
            {
                MessageBox.Show("Пароли должны совпадать!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Validation.IsValidPassword(password1))
            {
                MessageBox.Show("Пароль должен отвечать следующим требованиям: \n" +
                                "•	Минимум 6 символов\n" +
                                "•	Минимум 1 прописная буква\n" +
                                "•	Минимум 1 цифра\n" +
                                "•	По крайней мере один из следующих символов: ! @ # $ % ^", 
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (NewRunner.Age < 10)
            {
                MessageBox.Show("Бегуну должно быть не менее 10 лет!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        });

        public RunnerRegistrationPageViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            var syncContext = SynchronizationContext.Current;

            using var db = new AppDbContext();

            await db.Genders.ForEachAsync(x =>
            {
                syncContext.Invoke(() =>
                {
                    Genders.Add(x);
                });
            });

            await db.Countries.ForEachAsync(x =>
            {
                syncContext.Invoke(() =>
                {
                    Countries.Add(x);
                });
            });
        }
    }
}
