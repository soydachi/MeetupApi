 // ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class CreateEventModel
    {
        /// <summary>
        /// Longer description of the event, in HTML. May not be longer than 50000 characters.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Event duration in milliseconds. When not specified, a default of 3 hours may be assumed by applications. 
        /// To clear event duration, set this to 0
        /// </summary>
        public double Duration { get; set; }
        /// <summary>
        /// Number of guests members may include in their RSVP, 0 or more
        /// </summary>
        public int GuestLimit { get; set; }
        /// <summary>
        /// Up to 5 comma-separated valid member ids to be hosts for the event. 
        /// If hosts is not provided, the authorized member is the default host
        /// </summary>
        public string[] Hosts { get; set; }
        /// <summary>
        /// The information provided by the event host for "How will members find you there?". 
        /// Visible when location is visible to the authenticated member
        /// </summary>
        public string HowToFindUs { get; set; }
        /// <summary>
        /// If you are an organizer of the group, you may set this to "draft" to save the event as a draft. 
        /// Doing so will require a status=draft filter on /2/event queries.
        /// </summary>
        public PublishStatus PublishStatus { get; set; }
        /// <summary>
        /// Those with permission may include up to 6 survey questions for the event with each being up to 250 characters. 
        /// See the parameter notes section for more information
        /// </summary>
        public string[] Questions { get; set; }
        /// <summary>
        /// Users with permission may set the RSVP close time for the event. 
        /// The time may be specified in milliseconds since the epoch, or relative to the current time in the d/w/m format.
        /// </summary>
        public double RSVPClose { get; set; }
        /// <summary>
        /// Total number of RSVPs available for the event
        /// </summary>
        public int RSVPLimit { get; set; }
        /// <summary>
        /// Users with permission may set the RSVP open time for the event. 
        /// The time may be specified in milliseconds since the epoch, or relative to the current time in the d/w/m format.
        /// </summary>
        public double RSVPOpen { get; set; }
        /// <summary>
        /// Description of the event, in simple HTML format. This value is translated to HTML to update the description. 
        /// May not be longer than 50000 characters.
        /// </summary>
        public string SimpleHtmlDescription { get; set; }
        /// <summary>
        /// Event start time in milliseconds since the epoch, or relative to the current time in the d/w/m format.
        /// </summary>
        public double Time { get; set; }
        /// <summary>
        /// Numeric identifier of a venue
        /// </summary>
        public string VenueId { get; set; }
        /// <summary>
        /// Controls the visibility of the event venue for non members of the hosting group. 
        /// May be one of "public" or "members"
        /// </summary>
        public VenueVisibility VenueVisibility { get; set; }
        /// <summary>
        /// Waiting list status may be one of: auto, manual, off
        /// </summary>
        public Waitlisting Waitlisting { get; set; }
        /// <summary>
        /// We should do this because... May not be longer than 250 characters.
        /// </summary>
        public string Why { get; set; }
    }
}