using System;

namespace Sic.Art
{
    public static class CoolDogPiano
    {
        // Returns a simple SVG illustration of a cool dog playing a piano.
        public static string GetSvg()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 800 400"" width=""800"" height=""400"">
  <!-- Background -->
  <rect width=""100%"" height=""100%"" fill=""#1f1f1f"" />

  <!-- Stage spotlight -->
  <ellipse cx=""400"" cy=""80"" rx=""220"" ry=""80"" fill=""rgba(255,240,200,0.08)"" />

  <!-- Piano body -->
  <g transform=""translate(140,180)"">
    <rect x=""0"" y=""40"" width=""520"" height=""120"" rx=""12"" fill=""#222"" stroke=""#000"" stroke-width=""3"" />
    <rect x=""20"" y=""0"" width=""480"" height=""60"" rx=""6"" fill=""#111"" />
    <!-- Keys -->
    <g>
      <rect x=""30"" y=""40"" width=""440"" height=""40"" fill=""#fff"" />
      <!-- some black keys -->
      <rect x=""70"" y=""40"" width=""18"" height=""24"" fill=""#000"" />
      <rect x=""120"" y=""40"" width=""18"" height=""24"" fill=""#000"" />
      <rect x=""200"" y=""40"" width=""18"" height=""24"" fill=""#000"" />
      <rect x=""260"" y=""40"" width=""18"" height=""24"" fill=""#000"" />
      <rect x=""330"" y=""40"" width=""18"" height=""24"" fill=""#000"" />
    </g>
  </g>

  <!-- Dog body -->
  <g transform=""translate(340,90) scale(1.0)"">
    <!-- body -->
    <ellipse cx=""-40"" cy=""160"" rx=""60"" ry=""40"" fill=""#d6a85a"" stroke=""#6b3f1b"" stroke-width=""2"" />
    <!-- head -->
    <circle cx=""0"" cy=""90"" r=""44"" fill=""#d6a85a"" stroke=""#6b3f1b"" stroke-width=""2"" />
    <!-- sunglasses -->
    <rect x=""-22"" y=""78"" width=""20"" height=""12"" rx=""3"" fill=""#000"" />
    <rect x=""6"" y=""78"" width=""20"" height=""12"" rx=""3"" fill=""#000"" />
    <rect x=""-2"" y=""82"" width=""8"" height=""2"" fill=""#222"" />
    <!-- nose -->
    <ellipse cx=""0"" cy=""102"" rx=""6"" ry=""4"" fill=""#6b3f1b"" />
    <!-- smiling mouth -->
    <path d=""M -10 112 q 10 10 20 0"" stroke=""#6b3f1b"" stroke-width=""2"" fill=""none"" />

    <!-- left paw on keys -->
    <ellipse cx=""-70"" cy=""190"" rx=""18"" ry=""10"" fill=""#d6a85a"" stroke=""#6b3f1b"" stroke-width=""2"" transform=""rotate(-10 -70 190)"" />
    <!-- right paw on keys -->
    <ellipse cx=""-20"" cy=""190"" rx=""18"" ry=""10"" fill=""#d6a85a"" stroke=""#6b3f1b"" stroke-width=""2"" transform=""rotate(6 -20 190)"" />

    <!-- cool jacket -->
    <path d=""M -48 130 q 40 28 96 0 l -10 30 q -36 20 -76 0 z"" fill=""#0b5"" fill-opacity=""0.6"" stroke=""#063"" stroke-width=""2"" />
  </g>

  <!-- small caption -->
  <text x=""400"" y=""370"" font-family=""Arial"" font-size=""14"" fill=""#ddd"" text-anchor=""middle"">A cool dog playing piano</text>
</svg>";
        }

        // Prints a small ASCII-art dog with a piano hint to the console.
        public static void PrintAscii()
        {
            var art = @"       _.-._
     .'     '.
    /  O   O  \   🎹
   |  \  ^  /  |  |~~~~~~|
    \  '---'  /   | PIANO|
     '._____.'     |______|
       /| |\
      /_| |_\
";
            Console.WriteLine(art);
        }

        // Save the generated SVG to disk (overwrites if exists)
        public static void SaveSvgTo(string path)
        {
            System.IO.File.WriteAllText(path, GetSvg());
        }
    }
}
