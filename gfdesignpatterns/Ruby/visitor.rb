class Element
	def accept(visitor, from, to, value)
	raise NotImplementedError, "#{self.class.type} does not implement accept()"
	end
end

class TwoKeyDictionary < Element
	attr_reader :dictionary
	def initialize()
		@dictionary = {}
	end
	
	def add(key1, key2, value)
		addEntry(key1, key2, value);
		addEntry(key2, key1, (1.0/value));
		addEntry(key1, key1, 1.0);
		addEntry(key2, key2, 1.0);
	end
	
	def addEntry(key1, key2, value)
		currentDictionary = nil
		if @dictionary.has_key?(key1)
			currentDictionary = @dictionary[key1]
		else 
			currentDictionary = Operator.new()
			@dictionary[key1] = currentDictionary
		end
		
		if !currentDictionary.dictionary.has_key?(key2)
			currentDictionary.dictionary[key2]=value
		end
	end
	
	def accept(visitor, from, to, value)
		visitor.visit(self,from,to,value)
	end
	
end

class Operator
	attr_reader :dictionary
	def initialize()
		@dictionary = {}
	end
end


class OperationVisitor 
	def initialize()
		@visited = Array.new()
	end
	
	def visit(element, from, to, value)
		@visited = Array.new()
		
		resultDouble = visitLoop(element, from, to, value)
		if resultDouble !=nil
			puts "#{value} #{from} = #{resultDouble} #{to} "
		else
			puts "There was an error with the selected conversion"
		end
	end
	
	def visitLoop(element, from, to, value)
		if (!element.dictionary.has_key?(from) || @visited.include?(from))
			return nil
		end
		@visited << from
		values = Array.new()
		current = element.dictionary[from]
		if current.dictionary.has_key?(to)
			values << current.dictionary[to]
		else
			current.dictionary.each do |key, dvalue|
				values << visitLoop(element, key, to, dvalue)
			end
		end
		
		values.compact!
		if values.length==1
			return values[0]*value
		end
		return nil
	end
end
		
dictionary = TwoKeyDictionary.new()
dictionary.add("feet","inches",12.0)
dictionary.add("miles","feet",5280.0)
dictionary.add("cms","feet",2.54)
dictionary.add("A113","EACs",20)
dictionary.add("Piston Cups","Pizza Planet Trucks",943)
dictionary.add("EACs","Pizza Planet Trucks",1.25)
dictionary.add("BnLs","Piston Cups",5000)
dictionary.add("EACs","feet",660)
visitor = OperationVisitor.new()

##puts dictionary.dictionary.to_s		
puts "choose from these options"
dictionary.dictionary.each do |key, value|
	puts key
end

puts "\nFrom"
inputFrom = gets.chomp.to_s
puts "To"
inputTo = gets.chomp.to_s
puts "How Many"
inputHowMany = gets.chomp.to_f
dictionary.accept(visitor, inputFrom, inputTo, inputHowMany)
