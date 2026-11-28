using HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpDesk.Services
{
    public class TicketFilterService
    {
        public const string AllStatuses = "Все";

        public List<Ticket> Filter(IEnumerable<Ticket> tickets, string searchText, string status)
        {
            string text = (searchText ?? "").Trim();
            bool useStatus = !string.IsNullOrEmpty(status) && status != AllStatuses;

            return tickets
                .Where(t => !useStatus || t.Status == status)
                .Where(t => text.Length == 0 ||
                            Contains(t.Description, text) ||
                            Contains(t.Category, text) ||
                            Contains(t.Status, text))
                .ToList();
        }

        private static bool Contains(string source, string value)
        {
            return source != null &&
                   source.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
    }
}
