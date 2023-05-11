using BindableProps;
using FontAwesome;
using System.Globalization;

namespace CommunityFA.Controls;

public partial class DuoToneIcon : ContentView
{
    [BindableProp(PropertyChangedDelegate = nameof(OnHorizontalIconAlignmentPropertyChanged))]
    private TextAlignment _horizontalIconAlignment = TextAlignment.Start;

    [BindableProp(PropertyChangedDelegate = nameof(OnIconPropertyChanged))]
    private string _icon = FontAwesomeIcons.BlockQuestion;

    [BindableProp(PropertyChangedDelegate = nameof(OnIconSizePropertyChanged))]
    private double _iconSize = 12d;

    [BindableProp(PropertyChangedDelegate = nameof(OnPrimaryColorPropertyChanged))]
    private Color _primaryColor = Color.FromArgb("FF183153");

    [BindableProp(PropertyChangedDelegate = nameof(OnPrimaryOpacityPropertyChanged))]
    private double _primaryOpacity = 1d;

    [BindableProp(PropertyChangedDelegate = nameof(OnSecondaryColorPropertyChanged))]
    private Color _secondaryColor = Colors.Black;

    [BindableProp(PropertyChangedDelegate = nameof(OnSecondaryOpacityPropertyChanged))]
    private double _secondaryOpacity = 0.4d;


    [BindableProp(PropertyChangedDelegate = nameof(OnVerticalIconAlignmentPropertyChanged))]
    private TextAlignment _verticalIconAlignment = TextAlignment.Start;

    public DuoToneIcon()
    {
        InitializeComponent();
    }

    public string PrimaryText => Icon;

    public string SecondaryText => Icon + Icon; // This is the trick that let's us specifically target the second ligature

    private static void OnHorizontalIconAlignmentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DuoToneIcon control)
        {
            control.PrimaryLabel.HorizontalTextAlignment = (TextAlignment)newValue;
            control.SecondaryLabel.HorizontalTextAlignment = (TextAlignment)newValue;
        }
    }

    private static void OnIconPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DuoToneIcon control)
        {
            control.PrimaryLabel.Text = UnicodeToCharacter(newValue.ToString());
            control.SecondaryLabel.Text = UnicodeToCharacter(newValue.ToString()) + UnicodeToCharacter(newValue.ToString()); // This is the trick that let's us specifically target the second ligature
        }
    }

    private static void OnIconSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DuoToneIcon control)
        {
            control.PrimaryLabel.FontSize = (double)newValue;
            control.SecondaryLabel.FontSize = (double)newValue;
        }
    }

    private static void OnPrimaryColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DuoToneIcon control)
        {
            control.PrimaryLabel.TextColor = (Color)newValue;
        }
    }

    private static void OnPrimaryOpacityPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DuoToneIcon control)
        {
            control.PrimaryLabel.Opacity = (double)newValue;
        }
    }

    private static void OnSecondaryColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DuoToneIcon control)
        {
            control.SecondaryLabel.TextColor = (Color)newValue;
        }
    }

    private static void OnSecondaryOpacityPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DuoToneIcon control)
        {
            control.SecondaryLabel.Opacity = (double)newValue;
        }
    }

    private static void OnVerticalIconAlignmentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DuoToneIcon control)
        {
            control.PrimaryLabel.VerticalTextAlignment = (TextAlignment)newValue;
            control.SecondaryLabel.VerticalTextAlignment = (TextAlignment)newValue;
        }
    }

    private static string UnicodeToCharacter(string? inStr)
    {
        if (inStr == null) return string.Empty;

        bool success = int.TryParse(inStr, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int code);
        if (success)
        {
            return char.ConvertFromUtf32(code);
        }
        return inStr;
    }
}