using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("DateDimension")]
public class DateDimension
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // Otomatik artan değil, manuel (YYYYMMDD)
    public int DateKey { get; set; }

    public DateTime FullDate { get; set; }

    public int Day { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public int Quarter { get; set; }

    public int DayOfWeek { get; set; }

    public bool IsWeekend { get; set; }

    [Required, StringLength(20)]
    public string MonthName { get; set; } = string.Empty;
}