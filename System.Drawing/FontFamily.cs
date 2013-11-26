//
// System.Drawing.FontFamily.cs
//
// Author:
//   Dennis Hayes (dennish@Raytek.com)
//   Alexandre Pigolkine (pigolkine@gmx.de)
//   Peter Dennis Bartok (pbartok@novell.com)
//   Sebastien Pouliot  <sebastien@xamarin.com>
//   Kenneth J. Pouncey (kjpou@pt.lu)
//
// Copyright (C) 2002/2004 Ximian, Inc http://www.ximian.com
// Copyright (C) 2004 - 2006 Novell, Inc (http://www.novell.com)
// Copyright 2011 Xamarin Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System.Drawing.Text;

namespace System.Drawing 
{

	public sealed partial class FontFamily : MarshalByRefObject, IDisposable 
	{

		string familyName;

		public FontFamily(GenericFontFamilies genericFamily)
		{
			switch (genericFamily) 
			{
			case GenericFontFamilies.Monospace:
				familyName = MONO_SPACE;
				break;
			case GenericFontFamilies.SansSerif:
				familyName = SANS_SERIF;
				break;
			case GenericFontFamilies.Serif:
				familyName = SERIF;
				break;
			}

			CreateNativeFontFamily (familyName, true);
		}

		public FontFamily (string name)
		{			
			if (string.IsNullOrEmpty (name))
				throw new ArgumentException ("name can not be null or empty");


			familyName = name;

			CreateNativeFontFamily (familyName, false);
		}

		public string Name
		{
			get { return familyName; }
		}

		~FontFamily ()
		{
			Dispose (false);
		}
		
		public void Dispose ()
		{
			Dispose (true);
			System.GC.SuppressFinalize (this);
		}

		void Dispose (bool disposing)
		{
		}

		public override string ToString ()
		{
			return string.Format ("[FontFamily: Name={0}]", Name);
		}
	}
}