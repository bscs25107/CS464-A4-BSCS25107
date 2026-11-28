# CS464 LAB 07 · Ruhma Binte Asad · BSCS25107

**Demo Video:** [Drive link](https://drive.google.com/file/d/1X3yqN6eCIAuTkQHyBA3V6-1iX3j4Fv_3/view?usp=sharing)

### SCREENSHOTS (Black and white as well as Color)
##### Screen 1
<p>
<img src="Docs/1.jpeg" width="240">
<img src="Docs/1bw.jpeg" width="240">
</p>

##### Screen 2
<p>
<img src="Docs/2.jpeg" width="240">
<img src="Docs/2bw.jpeg" width="240">
</p>

##### Screen 3
<p>
<img src="Docs/3.jpeg" width="240">
<img src="Docs/3bw.jpeg" width="240">
</p>

##### Screen 4
<p>
<img src="Docs/4.jpeg" width="240">
<img src="Docs/4bw.jpeg" width="240">
</p>

##### Screen 5
<p>
<img src="Docs/5.jpeg" width="240">
<img src="Docs/5bw.jpeg" width="240">
</p>

##### Screen 6
<p>
<img src="Docs/6.jpeg" width="240">
<img src="Docs/6bw.jpeg" width="240">
</p>

##### Screen 7
<p>
<img src="Docs/7.jpeg" width="240">
<img src="Docs/7bw.jpeg" width="240">
</p>

##### Screen 8
<p>
<img src="Docs/8.jpeg" width="240">
<img src="Docs/8bw.jpeg" width="240">
</p>

##### Screen 9
<p>
<img src="Docs/9.jpeg" width="240">
<img src="Docs/9bw.jpeg" width="240">
</p>

##### Screen 10
<p>
<img src="Docs/10.jpeg" width="240">
<img src="Docs/10bw.jpeg" width="240">
</p>

##### Screen 11
<p>
<img src="Docs/11.jpeg" width="240">
<img src="Docs/11bw.jpeg" width="240">
</p>

##### Screen 12
<p>
<img src="Docs/12.jpeg" width="240">
<img src="Docs/12bw.jpeg" width="240">
</p>

### Settings and Pallete
| Part | Setting | Value | Why |
|:---|:---|:---|:---|
| A | Base hue | Triadiac · blue 240 degrees | blue base, red accent at 0°, offwhite and black accent at 120°  |
| A | Dark · mid · light | [#00008B] · [#B22222] · [#EEEDD6] | [dark for panels, mid for buttons, light for text] |
| A | Accents | [#FFFFFF] · [#000000] | far enough apart in value to read in grayscale |
| A | HUD text on its panel |12.91 : 1 | Cream on dark blue  is well above the 4.5 : 1 target because the text sits on a solid panel, not on the level.  |
| A | Button label on the button | 5.63 : 1 | Cream label on the red button, measured, above the 3 : 1 target for large text. |
| B | Music · SFX groups, as mixed | [-10] · [0] | Music sits below the effects so pickups, hits and clicks stay clear over the track.|
| B | Slider at 1 · 0.5 · 0.0001 | 0 dB · −6 dB · −80 dB | The slider value goes through Log10(value) × 20, because volume in decibels is logarithmic|
| C | [Guards], in [4] | Logarithmic · Min [2] · Max [20] | [reason for the rolloff and distances] |
| C | [Goal], in [4] | Linear · Min [3] · Max [30] | [reason for the rolloff and distances] |
| C | AudioListener | on the camera  | reason: e.g. camera is close behind the player |
| D | unlocked | int · default 1 | Level 1 is always open |
| D | best1 … best5 | float · HasKey first | no key means no time yet |
| D | MusicVolume | float · default 1 | full volume on run until changed by slider |

### Question and Answers
 **What `Time.timeScale = 0` stops in my game, and what it doesn't:**
Time.timeScale = 0 freezes physics and anything using Time.deltaTime, so the player, guards, and hazards stop moving. However, Update() still runs, so my player checks PauseMenu.IsPaused and returns early. The UI still works because it uses unscaled time. Music also continues unless AudioListener.pause = true, which my PauseMenu handles.

 **What survives a LoadScene in my game, and how:**
PersistentMusic and SfxPlayer survive scene changes using DontDestroyOnLoad, while their singleton checks prevent duplicates. PlayerPrefs also remain saved, along with static variables and events. That's why Resume() runs before loading a scene and Awake() resets the necessary statics. Other objects are recreated when the new scene loads.
 
 **Why every PlayerPrefs read in my game has a default:** 
On the first run, saved keys might not exist, so GetInt() would return 0. This could keep Level 1 locked or make the music silent because Log10(0) is undefined. My game uses defaults like unlocked = 1 and MusicVolume = 1 to avoid these problems. It also checks HasKey() before loading best times.
 
 **An exception a forgotten unsubscribe would throw, and why mine can't:** 
 If a script subscribes to Pickup.Collected but doesn't unsubscribe, the event can keep a reference to a destroyed object after a scene reload. When triggered again, it could throw a MissingReferenceException. I avoid this by unsubscribing with -= in OnDisable() for Hud, LevelObjective, and other listeners
 
## Credits
| Sound or track| Who made it | Link | Licence |
|:---|:---|:---|:---|
|13819 star twinkle ding | Robinhood76 |[Link](https://freesound.org/people/Robinhood76/sounds/819418/) | 13819 star twinkle ding by Robinhood76 -- https://freesound.org/s/819418/ -- License: Attribution NonCommercial 4.0|
| Echoing Wind Chimes over a Deep Low-Frequency Ambient Drone| bassimat | [Link](https://freesound.org/people/bassimat/sounds/867568/)| Echoing Wind Chimes over a Deep Low-Frequency Ambient Drone by bassimat -- https://freesound.org/s/867568/ -- License: Creative Commons 0|
|Jingle_Win_01.wav|LittleRobotSoundFactory| [Link](https://freesound.org/people/LittleRobotSoundFactory/sounds/270545/)|Jingle_Win_01.wav by LittleRobotSoundFactory -- https://freesound.org/s/270545/ -- License: Attribution 4.0|
|8-Bit Lose Life|Qvantor|[Link](https://freesound.org/people/Qvantor/sounds/878326/)|8-Bit Lose Life by Qvantor -- https://freesound.org/s/878326/ -- License: Creative Commons 0|
|Ambient Soundscape with Shimmer.flac|NickR2020|[Link](https://freesound.org/people/NickR2020/sounds/520598/)|Ambient Soundscape with Shimmer.flac by NickR2020 -- https://freesound.org/s/520598/ -- License: Attribution 3.0|
|slap_|Firecat_the_potato_YT|[Link](https://freesound.org/people/Firecat_the_potato_YT/sounds/551309/)|slap_ by Firecat_the_potato_YT -- https://freesound.org/s/551309/ -- License: Creative Commons 0|
| Sparkle Burst |Qvantor | [Link](https://freesound.org/people/Qvantor/sounds/880771/)|Sparkle Burst by Qvantor -- https://freesound.org/s/880771/ -- License: Creative Commons 0 
|
