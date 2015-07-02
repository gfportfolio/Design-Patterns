class Show 
	def initialize()
		@name
		@type
		@year
	end
	
	def name=(newName)
		@name = newName
	end
	
	def type=(newType)
		@type = newType
	end
	
	def year=(newYear)
		@year = newYear
	end
	
	def to_s
		"Name is: #{@name}  The Year is: #{@year}  The Type is: #{@type}"
	end
end

class Builder 
	def initialize()
		@show1 = Show.new();
	end
	
	def buildname(newName)
		@show1.name=newName
	end
	
	def buildyear(newYear)
		@show1.year=newYear
	end
	
	def buildtype()
		raise NotImplementedError, "#{self.class.type} does not implement buildType()"
	end
	
	def to_s
		@show1.to_s
	end
end

class BuildShort < Builder
	def buildtype()
		@show1.type="Short"
	end
end

class BuildMovie < Builder
	def buildtype()
		@show1.type="Movie"
	end
end

class Director
	def initialize()
	end
	
	def construct(builder, name, year)
		builder.buildname(name)
		builder.buildtype()
		builder.buildyear(year)
	end
end

director1 = Director.new()
movieBuilder = BuildMovie.new()
shortBuilder = BuildShort.new()

director1.construct(movieBuilder,"Inside Out",2015)
show1 = movieBuilder.to_s

director1.construct(movieBuilder,"Finding Nemo",2003)
show2 = movieBuilder.to_s

director1.construct(shortBuilder,"One Man Band",2005)
show3 = shortBuilder.to_s

director1.construct(shortBuilder,"Presto",2008)
show4 = shortBuilder.to_s

puts "Show 1"
puts show1.to_s

puts "Show 2"
puts show2.to_s

puts "Show 3"
puts show3.to_s

puts "Show 4"
puts show4.to_s


	
	
	
	
	
	
	
	
	
	
	