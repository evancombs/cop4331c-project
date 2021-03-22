# [U001]: As a user, I want to see a flora species in the ecosystem.
|no.   |Steps to Reproduce   |Expected Behavior   |
|---|---|---|
| 1.  | Click play in Unity editor  | flora GameObjects should spawn on screen | 
| 2.  | Click on a flora species in the unity scene | all flora objects should have a script component named "Flora", and the material should be green. |



## [U002]: As a user I want to be able to see an entity that represents a predator species.
|no.  |Steps to Reproduce   |Expected Behavior   |
|---|---|---|
| 1.  |  Click play in unity editor  | predator GameObjects should spawn on screen | 
| 2.  |  Click on a predator species in the unity scene | all predator objects should have a script component named "Predator", and the material should be red. | 


## [U003]: As a user I want to be able to see an entity that represents a prey species. 
|no.  |Steps to Reproduce   |Expected Behavior   |
|---|---|---|
| 1.  |  Click play in unity editor  | prey GameObjects should spawn on screen, all should have a script componenet named "Prey," and the material should be orange.  |
| 2.  |  Click on a prey species in the unity scene | all prey species should have a script component named "Prey", and the material should be orange. | 


## [U004]: As a user, I want to see a need for food/nutrients by the fauna. 
| no.  | Steps to Reproduce  | Expected Behavior |
|---|---|---|
| 1.  | click play button in unity editor  | fauna should spawn, over time the fauna should lose nutrient value.  |
| 2. | nutrientLevel <= 0  | once fauna start have no nutrient level, then they shall die. |




## [U005]: As a user, I would like to see a need for water by all organisms in the ecosystem/ Water sources should spawn. 
| no.  | Steps to Reproduce  | Expected Behavior |
|---|---|---|
| 1.  | click play button in unity editor  | water source GameObjects should spawn in the ecosystem. |
| 2.  | waterLevel <= 0  | All organisms should lose water level over time, if their water level reaches zero, then the organism shall die. | 
| 3.  | waterLevel <= 30 | Once in need of water, if an organism is near a water source, its water level will start to rise. |
| 4.  | waterLevel >= 30 | Once need of water has been met, if an organism is not near a water source, then it shall start to lose water level. |  





## [U012]: As a user, I want to see organisms capable of reproducing when in satisfactory conditions, to represent success/ reproductive health of a species.
| no.  | Steps to Reproduce  | Expected Behavior  |
|---|---|---|
| 1.  | Click on the play button in the unity editor  | click on a organism.  |
| 2.  | wait  | Once reproductive needs are met, then the organism should reproduce and a child should appear.  |


## [U017]: As a user, I want to see predator and prey dynamics of Fauna in the ecosystem
| no.  | Steps to Reproduce  | Expected Behavior  |
|---|---|---|
| 1.  | Click the play button in the unity editor  | predators and prey should move randomly |
| 2.  | nutrientLevel <= 25  | If predators are near a prey species they will attempt to path towards them. |
| 3.  | nutrientLevel <= 25, and predator is on top of prey | The predator should kill the prey and comsume the nutrients if needed. | 




## [U018]: As a user, I want to see a distinction between consumable plant and animal nutrients, i.e. carnivore and Herbivore.
| no.   | Steps to Reproduce  | Expected Behavior  |
|---|---|---|
| 1.  | Click on the play button in the unity editor | there should be plant nutrients(green), and animal nutrients(pink) |
| 2.  | Click on a "FaunaNutrient" in the unity scene  | material should be pink, and the size should depend on the remaining nutrients.  |
| 3.  | Click on a "FloraNutrient" in the unity scene  | material should be green, and the size should depend on the remaining nutrients. |

