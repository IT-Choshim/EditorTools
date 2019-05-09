
Main = {}
local this = Main
local GameObject = UnityEngine.GameObject
local Input = UnityEngine.Input
local Rigidbody = UnityEngine.Rigidbody

local player
local rigid
local force  --力

function this.Start()
    player = GameObject.Find("Player(Clone)")
    player:AddComponent(typeof(Rigidbody))
    rigid = player:GetComponent("Rigidbody")

    force = 5

end

function this.Update()
    local h = Input.GetAxis("Horizontal")
    local v = Input.GetAxis("Vertical")

    rigid : AddForce(Vector3(h,0,v) * force)
end
