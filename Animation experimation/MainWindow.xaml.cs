using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Animation_experimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ADVideo.Play();
            ADVideo.IsEnabled = true;   
            ADVideo.Position = new TimeSpan(0, 0, 1);
        }

        private void btnAnimate_Click(object sender, RoutedEventArgs e)
        {
            TransformGroup group = new TransformGroup();
            // rotate
            DoubleAnimation rAnimation = new DoubleAnimation();
            RotateTransform rotate = new RotateTransform();
            rect.RenderTransform = rotate;
            rect.RenderTransformOrigin = new Point(0.5, 0.5);
            rAnimation.From = 0;
            rAnimation.To = 360;
            rAnimation.RepeatBehavior = RepeatBehavior.Forever;


            rotate.BeginAnimation(RotateTransform.AngleProperty, rAnimation);

            //skew
            
            DoubleAnimation sAnimation = new DoubleAnimation();
            SkewTransform skew = new SkewTransform();
            rect.RenderTransform = skew;
            sAnimation.From = 0;
            sAnimation.To = 45;
            sAnimation.RepeatBehavior = RepeatBehavior.Forever;
            sAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            sAnimation.AutoReverse = true;

            //skew.BeginAnimation(SkewTransform.AngleXProperty, sAnimation);

            group.Children.Add(rotate);
            group.Children.Add(skew);
            rect.RenderTransform = group;
            group.BeginAnimation(RotateTransform.AngleProperty, rAnimation);
            group.BeginAnimation(SkewTransform.AngleXProperty, sAnimation);

            //color
            ColorAnimation color = new ColorAnimation();
            color.From = Colors.White;
            color.To = Colors.Green;
            //rect.BeginAnimation(SolidColorBrush.ColorProperty, color);
        }

        private void grow(object sender, RoutedEventArgs e)
        {
            DoubleAnimation growWide = new DoubleAnimation();
            DoubleAnimation growHeight = new DoubleAnimation();
            growWide.From = 50;
            growWide.To = 60;
            growWide.AutoReverse = true;
            //growWide.Duration = new Duration(TimeSpan.FromTicks(10000));
            growWide.RepeatBehavior = RepeatBehavior.Forever;

            growHeight.From = 20;
            growHeight.To = 30;
            //growHeight.Duration = new Duration(TimeSpan.FromTicks(10000));
            growHeight.AutoReverse = true;
            growHeight.RepeatBehavior = RepeatBehavior.Forever;
            btnAnimate.BeginAnimation(HeightProperty, growHeight);
            btnAnimate.BeginAnimation(WidthProperty, growWide);
        }
        
        private void shrink(object sender, RoutedEventArgs e)
        {
            btnAnimate.BeginAnimation(HeightProperty, null);
            btnAnimate.BeginAnimation(WidthProperty, null);
        }
    }
}
