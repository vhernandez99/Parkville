using Xamarin.Forms;

namespace Parkville.Helpers
{
    public static class CollectionViewSelectedColor
    {
        public static DataTemplate WithSelectedBackgroundColor(this DataTemplate template, Color backgroundColor)
        {
            return new DataTemplate(() =>
            {
                var content = template.CreateContent() as VisualElement;

                var backColorSetter = new Setter { Value = backgroundColor, Property = VisualElement.BackgroundColorProperty };

                var stateGroup = new VisualStateGroup { Name = "Common", TargetType = typeof(Grid) };

                var normalState = new VisualState
                {
                    Name = "Normal",
                    TargetType = typeof(Grid),
                    Setters = { }
                };

                var selectedState = new VisualState
                {
                    Name = "Selected",
                    TargetType = typeof(Grid),
                    Setters = { backColorSetter }
                };

                stateGroup.States.Add(normalState);
                stateGroup.States.Add(selectedState);

                VisualStateManager.SetVisualStateGroups(content, new VisualStateGroupList { stateGroup });

                return content;
            });
        }
    }
}
