﻿using System.ComponentModel.DataAnnotations;

namespace WebAPIDemoBlazor.Models
{
    public class Shirt
    {

		[Key]
		public int ShirtId { get; set; }

		[Display(Name = "Shirt Brand")]
		[Required]
		public string? Brand { get; set; }

		[Display(Name = "Shirt Color")]
		[Required]
		public string? Color { get; set; }

		[Display(Name = "Shirt Size")]
		public int? Size { get; set; }

		[Display(Name = "Shirt Gender")]
		[Required]
		public string? Gender { get; set; }

		[Display(Name = "Shirt Price")]
		public double? price { get; set; }

		public static IQueryable<string> GetDisplayNames()
		{
			var displayNames = typeof(Shirt).GetProperties()
				.Select(property =>
				{
					var displayAttribute = property.GetCustomAttributes(typeof(DisplayAttribute), true)
												   .Cast<DisplayAttribute>()
												   .FirstOrDefault();
					return displayAttribute?.Name ?? property.Name;
				})
				.AsQueryable();

			return displayNames;
		}
	}
}
