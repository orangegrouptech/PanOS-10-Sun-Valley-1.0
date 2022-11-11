# PanOS-10-Sun-Valley-1.0
# NOTICE: DO NOT USE THIS CODE FOR MALICIOUS PURPOSES. I AM NOT RESPONSIBLE FOR ANY DAMAGE DONE.

Finally, the source code of Install PanOS 10 Sun Valley. Don't ask why the different components have their own solutions. It totally wasn't because I didn't know you could add more than one project to a solution.

Components:
- auth (The authentication window that prompts for the key)
- BlacklistedApp (The executable that will replace blacklisted system files and will show the flying PanOS window instead)
- GoodbyeMBR (Overwrites MBR)
- PanOSMain (The main draggable PanOS window you first see when the payload starts)
- PanOSMainOld (A WindowsForms prototype of PanOSMain that was half completed until I hit a limitation of WindowsForms and switched to the main WPF version instead. Don't know if this will run after you compile it out of the box, includes an older version of the VM-only protection that is half broken [it was the time when I was still trying to figure that out]. DO NOT RUN ON HOST.)
- phase3 (The window you see when it reboots to Safe Mode)
- UpdateScreen (The window you see after you authenticate)
- Wireframe (Contains screenshots of the Windows 10 Update Assistant for reference when I was making this malware)
- PanOSLaunchHelper (Ok, this one has a bit of a backstory. For some reason, PanOSMain.exe failed to launch automatically even with the Shell key thing. So I made a VBS file to do that.)

Note:
- **This version still has the VM-only protections in place. I HIGHLY DO NOT RECOMMEND YOU REMOVE THEM AND COMPILE A VERSION WITHOUT THEM. DO SO AT YOUR OWN RISK.**
- This version has the API key of the auth service used removed but its code still remains. So you can see for yourselves why it was so troublesome whenever the service changed the SSL certificate.
- All WindowsForms components are not optimised for high DPI displays. I overlooked that when making this malware.
- You may see a Confused folder in the output directory of the various components. I don't know how up-to-date those versions are, you can probably find some prototypes/private beta versions there, if you can deobfuscate them.)
- The compiled executables in the output directories might not necessarily be up-to-date.
- You probably will have to remove the authentication part of the "auth" solution before compiling for it to work.