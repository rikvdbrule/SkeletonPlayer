using Kinect.Toolbox.Record;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.SkeletonBasics
{
    class SkeletonPlaybackManager
    {
        private String _File;
        private MainWindow parent;

        public bool PlayBack { get; private set; }

        public String SkeletonFile 
        {
            get {
                return _File;}
            set {
                if (!this.PlayBack)
                {
                    _File = value;
                }
            }
        }

        public SkeletonPlaybackManager(MainWindow parent)
        {
            this.parent = parent;
            this.PlayBack = false;
        }

        public void Start()
        {
            ReadSkeletonFile();
        }

        private void ReadSkeletonFile()
        {
            using (FileStream fs = File.Open(SkeletonFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            {
                KinectReplay reader = new KinectReplay(bs);
                reader.SkeletonFrameReady += parent.ReplayFrameReady;
                reader.Start();
            }
                            
        }
    }
}
