namespace Hotel.App.Models.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    public class ControlPanelViewModel
    {
        [DisplayName("Тип")]
        public string Type { get; set; }

        public IEnumerable<SelectListItem> ReviewsTypes { get; set; }

        [DisplayName("Сортирай")]
        public string Order { get; set; }

        public IEnumerable<SelectListItem> ReviewsSortOrder { get; set; }
    }
}