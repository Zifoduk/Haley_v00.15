﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Haley.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Haley.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap HaleyActive {
            get {
                object obj = ResourceManager.GetObject("HaleyActive", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap HaleyAwake {
            get {
                object obj = ResourceManager.GetObject("HaleyAwake", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Greatings&gt;
        ///[ hello, hi, hola, wagwan ]
        ///&lt;Time Request&gt;
        ///[ what is the time, what&apos;s the time, tell me the time ]
        ///&lt;Leaving&gt;
        ///[ bye, seeya, good bye ]
        ///&lt;Date&gt;
        ///[ What&apos;s the date, What is the date, what day is it today, what&apos;s the date today ]
        ///&lt;Wake&gt;
        ///[ haley ]
        ///&lt;SMusic&gt;
        ///[ select music, i need music, select song ]
        ///&lt;PMusic&gt;
        ///[ play music, unpause the music, play the song ]
        ///&lt;EMusic&gt;
        ///[ pause the music, pause the song, stop the music ]
        ///&lt;NMusic&gt;
        ///[ next song, skip song, skip track, play the next song, skip  [rest of string was truncated]&quot;;.
        /// </summary>
        public static string HaleyCommands {
            get {
                return ResourceManager.GetString("HaleyCommands", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Intro&gt;
        ///[Welcome Sir this is haley, Haley Lock and Load, Haley Is fully operational Sir, Sir I&apos;m Alive ]
        ///&lt;Greatings&gt;
        ///[ Wagwan Sir, Hello Sir, Whats up Sir, Hi Sir, Yes Sir ]
        ///&lt;Time Request&gt;
        ///[ the time is, currently it is, Right now is, Time right now is]
        ///&lt;Leaving&gt;
        ///[ bye bye sir, seeya sir, good bye sir ]
        ///&lt;Date&gt;
        ///[ the date is, the Date Today is, today is ]
        ///&lt;Wake&gt;
        ///[ Yes sir , here sir]
        ///&lt;Music&gt;
        ///[ What song sir , Which song would you like]
        ///&lt;Cancel&gt;
        ///[ Cancelling, Ending Process, Cancelled, Ended, O [rest of string was truncated]&quot;;.
        /// </summary>
        public static string HaleyResponce {
            get {
                return ResourceManager.GetString("HaleyResponce", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        public static System.Drawing.Bitmap HaleySleep {
            get {
                object obj = ResourceManager.GetObject("HaleySleep", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
