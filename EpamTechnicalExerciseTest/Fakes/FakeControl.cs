using System.Windows;
using System.Windows.Controls;

namespace EpamTechnicalExerciseTest.Fakes
{
    public class FakeControl : Control
    {
        public static readonly DependencyProperty FakeDependencyProperty = DependencyProperty.Register("FakeDependency", typeof(string), typeof(FakeControl));
    }
}
