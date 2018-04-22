#import <Foundation/Foundation.h>
#import <AudioToolbox/AudioServices.h>

extern "C"
{
    int cnt = 1;
    void ExecuteVibration(SystemSoundID ssID,void *clientData)
    {
        if (cnt > 0)
        {
            [NSThread sleepForTimeInterval:(NSTimeInterval)1.0];
            AudioServicesPlaySystemSound(kSystemSoundID_Vibrate);
        }
        else{
            AudioServicesRemoveSystemSoundCompletion(kSystemSoundID_Vibrate);
            
        }
        cnt--;
    }
    
    void _PlayVibration(int i)
    {
        cnt = i;
        AudioServicesAddSystemSoundCompletion(kSystemSoundID_Vibrate,NULL,NULL,ExecuteVibration,NULL);
        AudioServicesPlaySystemSound(kSystemSoundID_Vibrate);
        
    }
}
