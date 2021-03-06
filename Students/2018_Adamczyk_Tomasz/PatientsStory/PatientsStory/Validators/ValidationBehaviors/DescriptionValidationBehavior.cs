﻿using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace PatientsStory.Validators
{
    public class DescriptionValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var description = textChangedEventArgs.NewTextValue;
            var descriptionEntry = sender as Entry;

            if (Regex.IsMatch(description, RegexPatterns.descriptionPattern))
            {
                descriptionEntry.TextColor = Color.Black;
            }
            else
            {
                descriptionEntry.TextColor = Color.Red;
            }
        }
    }
}