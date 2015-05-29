$singleton = nil

class Show
	def initialize(name, year)
		@name = name
		@year = year
	end
	
	def getYear
		@year
	end
	
	def getName
		@name
	end
end

class Singleton
	@movies = []
	@shorts = []
	
	def getMovies()
		@movies
	end
	
	def getShorts()
		@shorts
	end
	
	def addMovie(show)
		@movies+show
	end
	
	def addShort(show)
		@shorts+show
	end
	
	def initialize()
		addMovie(Show.new("Toy Story",1995))
		addMovie(Show.new("Bugs Life", 1998))
		addShort(Show.new("Luxo Jr.",1986))
		addShort(Show.new("The Blue Umbrella", 2013))
	end
	
	def getSingleton()
		if (!$singleton ==nil)
			$singleton = new Singleton()
			$singleton
			
		else
			$singleton
			
		end
	end
	
	def printMovies()
		put "Movies"
		@movies.each do |show|
			put (show.name + " " + show.year)
		end
	end
	
	def printShorts()
		put "Shorts"
		@movies.each do |show|
			put (show.name + " " + show.year);
		end
	end
	
	def printAll()
		printMovies();
		put ""
		printShorts();
	end
	
end




mysingelton = Singleton.new

mysingelton.printAll()