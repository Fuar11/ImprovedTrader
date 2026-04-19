namespace ImprovedTrader
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public class Settings : JsonModSettings
	{
		internal static Settings Instance { get; } = new();

		[Section("Trader Tunables")]

		[Name("Days To Arrival")]
		[Description("Number of days until the trader becomes available.")]
		[Slider(0f, 35f)]
		public float traderAvailableDays = 10f;

		// this is called whenever there is a change. Ensure it contains the null bits that the base method has
		/// <inheritdoc/>
		protected override void OnChange(FieldInfo field, object? oldValue, object? newValue)
		{
			base.OnChange(field, oldValue, newValue);
		}

		// MUST be static
		// This is used to load the settings
		internal static void OnLoad()
		{
			Instance.AddToModSettings(BuildInfo.GUIName);
			Instance.RefreshGUI();
		}
	}
}
