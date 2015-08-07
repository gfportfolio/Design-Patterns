class player
	def initalize(name, life, strength, good)
	@name = name
	@life = life	
	@strength = strength
	@good = good
	@alive = true
	
	end
	
	def battle(attackerPower)
		@life -= attackerPower/@strength
		
		if @life<=0
			@alive = false
		end
	end
	
	def getPower()
		return @strength * @life
	end
	
	def to_s
		if @alive ==true
			puts "#{@name} servived the battle and has #{@life} left.\n"
		else
			puts "#{@name} has died in the battle.\n"
		end
	end
end

class class goodPlayer < player
	def initalize(name, life, strength)
	super(name, life, strength, true)
	end
end

class class badPlayer < player
	def initalize(name, life, strength)
	super(name, life, strength, false)
	end
end

class gameManager
	def initalize()
		@players 
		@players<<goodPlayer.new("Woody",5, 20)
		@players<<goodPlayer.new("Marida",12, 20)
		@players<<goodPlayer.new("Dash",8, 20)
		@players<<goodPlayer.new("Lightning",10, 20)		
		@players<<goodPlayer.new("Sully",15, 20)
		@players<<badPlayer.new("Hamm",3,20)
		@players<<badPlayer.new("Witch",11,20)
		@players<<badPlayer.new("Syndrome",10,20)
		@players<<badPlayer.new("Chick",13,20)
		@players<<badPlayer.new("Randell",8,20)
	end
		
	def getPlayers(good)
		playerList
			
		
	def round(playerNumber)
	
	goodPlayer = @player[playerNumber]
	
		if !goodPlayer.alive
			return "#{goodPlayer.name} is Dead and can ot go to battle."
		end
		
		
		availableBadPlayers 