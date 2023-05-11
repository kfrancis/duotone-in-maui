# duotone-in-maui
Working FontAwesome v6 DuoTone icon in Maui 

## Adapted from
https://gist.github.com/tomh4/e3a37f1abba2361ed02c09577dc2f09c

## Usage
```csharp
<ContentPage
	xmlns:controls="clr-namespace:CommunityFA.Controls;assembly=CommunityFA.Controls"
	xmlns:fa="clr-namespace:FontAwesome;assembly=CommunityFA.Controls"
	...
	>
```

```xml
<controls:DuoToneIcon Icon="{x:Static fa:FontAwesomeIcons.BatteryLow}" IconSize="32" />
```

## Sample

![Sample](https://raw.githubusercontent.com/kfrancis/duotone-in-maui/main/1m7jj-1683831916-150516.png)

To run the sample, download the pro for web package and place the duotone font file `fa-duotone-900.ttf` in `CommunityFA.Controls.SampleViewer/Resources/Fonts`

## TODO
- [x] Basic DuoTone Control
- [ ] Animation
- [ ] Opacity Swap Property