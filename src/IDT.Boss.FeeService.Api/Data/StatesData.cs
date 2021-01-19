using System.Collections.Generic;
using IDT.Boss.FeeService.Api.Enums;
using IDT.Boss.FeeService.Api.Models;

namespace IDT.Boss.FeeService.Api.Data
{
    // TODO: ideally this information can be moved to the database/storage or another helper service.

    /// <summary>
    /// Static test data for States and Exception States.
    /// </summary>
    public static class StatesData
    {
        /// <summary>
        /// Lookup with all the states.
        /// </summary>
        public static readonly IReadOnlyList<State> States = new List<State>
        {
            new State {Id = 1, Code = "AL", Name = "Alabama", Channel = Channel.US},
            new State {Id = 2, Code = "AK", Name = "Alaska", Channel = Channel.US},
            new State {Id = 3, Code = "AR", Name = "Arkansas", Channel = Channel.US},
            new State {Id = 4, Code = "AZ", Name = "Arizona", Channel = Channel.US},
            new State {Id = 5, Code = "CA", Name = "California", Channel = Channel.US},
            new State {Id = 6, Code = "CO", Name = "Colorado", Channel = Channel.US},
            new State {Id = 7, Code = "CT", Name = "Connecticut", Channel = Channel.US},
            new State {Id = 8, Code = "DC", Name = "District of Columbia", Channel = Channel.US},
            new State {Id = 9, Code = "DE", Name = "Delaware", Channel = Channel.US},
            new State {Id = 10, Code = "FL", Name = "Florida", Channel = Channel.US},
            new State {Id = 11, Code = "GA", Name = "Georgia", Channel = Channel.US},
            new State {Id = 12, Code = "HI", Name = "Hawaii", Channel = Channel.US},
            new State {Id = 13, Code = "IA", Name = "Iowa", Channel = Channel.US},
            new State {Id = 14, Code = "ID", Name = "Idaho", Channel = Channel.US},
            new State {Id = 15, Code = "IL", Name = "Illinois", Channel = Channel.US},
            new State {Id = 16, Code = "IL", Name = "Indiana", Channel = Channel.US},
            new State {Id = 17, Code = "KS", Name = "Kansas", Channel = Channel.US},
            new State {Id = 18, Code = "LY", Name = "Kentucky", Channel = Channel.US},
            new State {Id = 19, Code = "LA", Name = "Louisiana", Channel = Channel.US},
            new State {Id = 20, Code = "MA", Name = "Massachusetts", Channel = Channel.US},
            new State {Id = 21, Code = "MD", Name = "Maryland", Channel = Channel.US},
            new State {Id = 22, Code = "ME", Name = "Maine", Channel = Channel.US},
            new State {Id = 23, Code = "MI", Name = "Michigan", Channel = Channel.US},
            new State {Id = 24, Code = "MN", Name = "Minnesota", Channel = Channel.US},
            new State {Id = 25, Code = "MO", Name = "Missouri", Channel = Channel.US},
            new State {Id = 26, Code = "MS", Name = "Mississippi", Channel = Channel.US},
            new State {Id = 27, Code = "MT", Name = "Montana", Channel = Channel.US},
            new State {Id = 28, Code = "NC", Name = "North Carolina", Channel = Channel.US},
            new State {Id = 29, Code = "ND", Name = "North Dakota"},
            new State {Id = 30, Code = "NE", Name = "Nebraska", Channel = Channel.US},
            new State {Id = 31, Code = "NH", Name = "New Hampshire", Channel = Channel.US},
            new State {Id = 32, Code = "NJ", Name = "New Jersey", Channel = Channel.US},
            new State {Id = 33, Code = "NM", Name = "New Mexico", Channel = Channel.US},
            new State {Id = 34, Code = "NV", Name = "Nevada", Channel = Channel.US},
            new State {Id = 35, Code = "NY", Name = "New York", Channel = Channel.US},
            new State {Id = 36, Code = "OK", Name = "Oklahoma", Channel = Channel.US},
            new State {Id = 37, Code = "OH", Name = "Ohio", Channel = Channel.US},
            new State {Id = 38, Code = "OR", Name = "Oregon", Channel = Channel.US},
            new State {Id = 39, Code = "PA", Name = "Pennsylvania", Channel = Channel.US},
            new State {Id = 40, Code = "RI", Name = "Rhode Island", Channel = Channel.US},
            new State {Id = 41, Code = "SC", Name = "South Carolina", Channel = Channel.US},
            new State {Id = 42, Code = "SD", Name = "South Dakota", Channel = Channel.US},
            new State {Id = 43, Code = "TN", Name = "Tennessee", Channel = Channel.US},
            new State {Id = 44, Code = "TX", Name = "Texas", Channel = Channel.US},
            new State {Id = 45, Code = "UT", Name = "Utah", Channel = Channel.US},
            new State {Id = 46, Code = "VA", Name = "Virginia", Channel = Channel.US},
            new State {Id = 47, Code = "VT", Name = "Vermont", Channel = Channel.US},
            new State {Id = 48, Code = "WA", Name = "Washington", Channel = Channel.US},
            new State {Id = 49, Code = "WI", Name = "Wisconsin", Channel = Channel.US},
            new State {Id = 50, Code = "WV", Name = "West Virginia", Channel = Channel.US},
            new State {Id = 51, Code = "WY", Name = "Wyoming", Channel = Channel.US},
            // Territories
            new State {Id = 52, Code = "PR", Name = "Puerto Rico", Channel = Channel.US},
            new State {Id = 53, Code = "AS", Name = "American Samoa", Channel = Channel.US},
            new State {Id = 54, Code = "GU", Name = "Guam", Channel = Channel.US},
            new State {Id = 55, Code = "MP", Name = "Northern Mariana Islands", Channel = Channel.US},
            new State {Id = 56, Code = "VI", Name = "U.S. Virgin Islands", Channel = Channel.US}
        };

        /// <summary>
        /// Excluded stated - only if exists record.
        /// </summary>
        public static readonly IReadOnlyList<ExceptionState> ExceptionStates = new List<ExceptionState>
        {
            new ExceptionState {StateId = 6, IsExcluded = true, Notes = "Welcome to Colorful Colorado!"}
        };
    }
}