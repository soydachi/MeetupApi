using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Meetup.Api.Annotations;

// ReSharper disable once CheckNamespace
namespace Meetup.Api
{
    public class MeetupEvent
    {
        /// <summary>
        /// Searches for recent and upcoming public events hosted by Meetup groups. Its search window is the past one month through the 
        /// next three months, and is subject to change. Open Events is optimized to search for current events by location, category, 
        /// topic, or text, and only lists Meetups that have 3 or more RSVPs. The number or results returned with each request is not 
        /// guaranteed to be the same as the page size due to secondary filtering. 
        /// </summary>
        /// <param name="topic">Return events in the specified topic or topics specified by commas. This is the topic "urlkey" returned by the 
        /// Topics method. If all supplied topics are unknown, a 400 error response is returned with the code "badtopic".</param>
        /// <param name="lat">A valid latitude, limits the returned group events to those within radius miles</param>
        /// <param name="lon">A valid longitude, limits the returned group events to those within radius miles</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task&lt;OpenEvents&gt;.</returns>
        /// <exception cref="HttpRequestException">
        ///     Ops! Something went wrong :S. Please try again, if the error persist contact
        ///     with the developer to fix the issue.
        /// </exception>
        public async Task<Events> OpenEvents([NotNull]string topic, [NotNull]string lat, [NotNull]string lon, CancellationToken cancellationToken)
        { 
            if (string.IsNullOrEmpty(topic)) throw new ArgumentException("Argument is null or empty", nameof(topic));
            if (string.IsNullOrEmpty(lon)) throw new ArgumentException("Argument is null or empty", nameof(lon));
            if (string.IsNullOrEmpty(lat)) throw new ArgumentException("Argument is null or empty", nameof(lat));
            if (string.IsNullOrWhiteSpace(topic)) throw new ArgumentException("Argument is null or whitespace", nameof(topic));
            if (string.IsNullOrWhiteSpace(lon)) throw new ArgumentException("Argument is null or whitespace", nameof(lon));
            if (string.IsNullOrWhiteSpace(lat)) throw new ArgumentException("Argument is null or whitespace", nameof(lat));

            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
#if DEBUG
            queryUrl.Append($"/2/open_events?{SecretKeys.ApiKeyUrl}&lat={lat}&topic={topic}&lon={lon}");
#else
            queryUrl.Append($"/2/open_events?&lat={lat}&topic={topic}&lon={lon}");
#endif
            var response =
                await MeetupBase.ExecuteQueryAsync<Events>(queryUrl, cancellationToken);

            if (response == null)
                throw new HttpRequestException(Resources.ErrorMessage);
            return response;
        }

        /// <summary>
        /// Recommends upcoming meetups for the authorized member in a given location and in thier groups
        /// </summary>
        /// <param name="lat">A valid latitude, limits the returned group events to those within radius miles</param>
        /// <param name="lon">A valid longitude, limits the returned group events to those within radius miles</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task&lt;OpenEvents&gt;.</returns>
        /// <exception cref="HttpRequestException">
        ///     Ops! Something went wrong :S. Please try again, if the error persist contact
        ///     with the developer to fix the issue.
        /// </exception>
        public async Task<Events> Concierge([NotNull]string lat, [NotNull]string lon, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(lon)) throw new ArgumentException("Argument is null or empty", nameof(lon));
            if (string.IsNullOrEmpty(lat)) throw new ArgumentException("Argument is null or empty", nameof(lat));
            if (string.IsNullOrWhiteSpace(lon)) throw new ArgumentException("Argument is null or whitespace", nameof(lon));
            if (string.IsNullOrWhiteSpace(lat)) throw new ArgumentException("Argument is null or whitespace", nameof(lat));

            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
#if DEBUG
            queryUrl.Append($"/2/concierge?{SecretKeys.ApiKeyUrl}&lat={lat}&lon={lon}");
#else
            queryUrl.Append($"/2/concierge?&lat={lat}&lon={lon}");
#endif
            var response =
                await MeetupBase.ExecuteQueryAsync<Events>(queryUrl, cancellationToken);

            if (response == null)
                throw new HttpRequestException(Resources.ErrorMessage);
            return response;
        }

        /// <summary>
        /// Access Meetup events using a group, member, or event id. Events in private groups are available only to authenticated members of those groups.
        /// </summary>
        /// <param name="groupUrl">Path to group from meetup.com, no slashes</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task&lt;OpenEvents&gt;.</returns>
        /// <exception cref="HttpRequestException">
        ///     Ops! Something went wrong :S. Please try again, if the error persist contact
        ///     with the developer to fix the issue.
        /// </exception>
        public async Task<Events> Events([NotNull]string groupUrl, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(groupUrl)) throw new ArgumentException("Argument is null or empty", nameof(groupUrl));
            if (string.IsNullOrWhiteSpace(groupUrl)) throw new ArgumentException("Argument is null or whitespace", nameof(groupUrl));

            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
#if DEBUG
            queryUrl.Append($"/2/events?{SecretKeys.ApiKeyUrl}&group_urlname={groupUrl}");
#else
            queryUrl.Append($"/2/events?&group_urlname={groupUrl}");
#endif
            var response =
                await MeetupBase.ExecuteQueryAsync<Events>(queryUrl, cancellationToken);

            if (response == null)
                throw new HttpRequestException(Resources.ErrorMessage);
            return response;
        }

        /// <summary>
        /// Fetches a Meetup Event by group urlname and event_id
        /// </summary>
        /// <param name="urlName">The urlname path element may be any valid group urlname.</param>
        /// <param name="id">The id path element must be a valid alphanumeric Meetup Event identifier</param>
        /// <param name="cancellationToken">Cancellation Token</param>
        /// <returns>Task&lt;Event&gt;.</returns>
        /// <exception cref="HttpRequestException">
        ///     Ops! Something went wrong :S. Please try again, if the error persist contact
        ///     with the developer to fix the issue.
        /// </exception>
        public async Task<Event> Event([NotNull]string urlName, [NotNull]string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(urlName)) throw new ArgumentException("Argument is null or empty", nameof(urlName));
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Argument is null or empty", nameof(id));
            if (string.IsNullOrWhiteSpace(urlName)) throw new ArgumentException("Argument is null or whitespace", nameof(urlName));
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Argument is null or whitespace", nameof(id));

            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);
            queryUrl.Append($"/{urlName}/events/{id}/");

            var response =
                await MeetupBase.ExecuteQueryAsync<Event>(queryUrl, cancellationToken);

            if (response == null)
                throw new HttpRequestException(Resources.ErrorMessage);
            return response;
        }

        public async Task<Events> Create([NotNull]string groupUrl, [NotNull]string name, CreateEventModel content, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(groupUrl)) throw new ArgumentException("Argument is null or empty", nameof(groupUrl));
            if (string.IsNullOrWhiteSpace(groupUrl)) throw new ArgumentException("Argument is null or whitespace", nameof(groupUrl));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Argument is null or empty", nameof(name));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Argument is null or whitespace", nameof(name));

            var queryUrl = new StringBuilder(MeetupBase.BASE_URL);

            var hosts = content.Hosts[0];
            for (var i = 1; i < content.Hosts.Length; i++)
            {
                hosts += $",{content.Hosts[i]}";
            }

            var htmlContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("description", content.Description), 
                new KeyValuePair<string, string>("duration", content.Duration.ToString()), 
                new KeyValuePair<string, string>("guest_limit", content.GuestLimit.ToString()), 
                new KeyValuePair<string, string>("hosts", content.Hosts.ToString()), 
                new KeyValuePair<string, string>("how_to_find_us", content.HowToFindUs), 
                new KeyValuePair<string, string>("publish_status", content.PublishStatus.ToString()), 
                //new KeyValuePair<string, string>("question_1", ), 
                new KeyValuePair<string, string>("rsvp_close", content.RSVPClose.ToString()), 
                new KeyValuePair<string, string>("rsvp_limit", content.RSVPLimit.ToString()), 
                new KeyValuePair<string, string>("rsvp_open", content.RSVPOpen.ToString()), 
                new KeyValuePair<string, string>("simple_html_description", content.SimpleHtmlDescription), 
                new KeyValuePair<string, string>("time", content.Time.ToString()), 
                new KeyValuePair<string, string>("venue_id", content.VenueId), 
                new KeyValuePair<string, string>("venue_visibility", content.VenueVisibility.ToString()), 
                new KeyValuePair<string, string>("waitlisting", content.Waitlisting.ToString()), 
                new KeyValuePair<string, string>("why", content.Why)
            });

#if DEBUG
            queryUrl.Append($"/2/event?{SecretKeys.ApiKeyUrl}&group_urlname={groupUrl}");
#else
            queryUrl.Append($"/2/event?&group_urlname={groupUrl}");
#endif
            for (int i = 0; i < content.Questions.Length; i++)
            {
                queryUrl.Append($"&question{i}={content.Questions[i]}");
            }

            var response =
                await MeetupBase.ExecuteQueryAsync<Events>(queryUrl, cancellationToken, htmlContent, HttpMethodTypes.POST);

            if (response == null)
                throw new HttpRequestException(Resources.ErrorMessage);
            return response;
        }
    }

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

    public enum Waitlisting
    {
        auto,
        manual,
        off
    }

    public enum VenueVisibility
    {
        @public,
        members
    }

    public enum PublishStatus
    {
        upcoming,
        past,
        proposed,
        suggested,
        cancelled,
        draft
    }
}