using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class Events
    {
        public List<Event> results { get; set; }
        public Meta meta { get; set; }
    }
}