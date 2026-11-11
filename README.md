# Radiant Commissions
A mod to generate random commissions.

## Project Structure

### 1. RadiantPlugin (Plugin)
"Application layer"
* Actual entrypoint for the mod
* Makes sure there's only one mod
* Delegates to RadiantCommission and RadiantUI

### 2. RadiantUI (UI)
* Envelope used to get new commissions
* Form/Letter/? to display commission offer
* Buttons to accept/decline

### 3. RadientCommission (Commission)
* Generate new commissions

## Plan

1. Envelope exists on desk by the Pigeon/Bell
2. When the player clicks on the Envelope:
	1. Generate a new random commission
	2. Display the new commission to the player
	3. Have buttons to Accept/Decline/Decline & read next
3. When the player selects a button from 2.3:
	* **Accept**: Add commission to the sketchbook
	* **Decline**: Close form/display window
	* **Decline & read next**: restart at step 2

### Notes/For the future:
* Need to be able to delete the commission from the sketchbook
* Set limit on # of radiant commissions that can be accepted at once?
* Generate measurements? 
* Might need a shared project if there's shared strings or anything between UI and Commission