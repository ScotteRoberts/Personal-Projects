<template>

  <section class="panel">
    <!-- DEV: Title and text input for ToDos -->
    <header>
      <p class="panel-heading has-text-centered">
        Todos
      </p>
      <div class="panel-block">
        <input
          type="checkbox"
          v-model="allDone"
          v-show="todos.length"
        >
        <p class="control">
          <input
            class="input"
            autofocus
            autocomplete="off"
            placeholder="What needs to be done?"
            v-model="newTodo"
            @keyup.enter="addTodo"
          >
        </p>
      </div>
    </header>

    <!-- DEV: ToDo items with filters -->

    <body v-show="todos.length">
      <label
        v-for="todo in filteredTodos"
        class="panel-block"
        :key="todo.id"
      >
        <input
          type="checkbox"
          v-model="todo.completed"
        >
        <p
          class="control"
          :class="{ strike: todo.completed}"
        >
          {{ todo.title }}
        </p>
        <button
          class="delete"
          @click="removeTodo(todo)"
        ></button>
      </label>
      <p class="panel-tabs">
        <a
          @click="onFilterChange('all')"
          :class="{ 'is-active': visibility == 'all' }"
        >All</a>
        <a
          @click="onFilterChange('active')"
          :class="{ 'is-active': visibility == 'active' }"
        >Active</a>
        <a
          @click="onFilterChange('completed')"
          :class="{ 'is-active': visibility == 'completed' }"
        >Completed</a>
      </p>

      <!-- DEV: Remaining Number of ToDos -->

      <div class="panel-block">
        <p class="control is-small">
          <strong>{{ remaining }}</strong> {{ remaining | pluralize }} left
        </p>
        <div
          class="control"
          v-show="todos.length > remaining"
        >
          <!-- DEV: Clear Completed ToDos -->
          <button
            class="button is-small"
            @click="removeCompleted"
          >
            Clear Completed
          </button>
        </div>
      </div>
    </body>
  </section>
</template>

<script>
// Full spec-compliant TodoMVC with localStorage persistence
// and hash-based routing in ~120 effective lines of JavaScript.

// localStorage persistence
var STORAGE_KEY = "todos-vuejs-2.0";
var todoStorage = {
  fetch: function() {
    var todos = JSON.parse(localStorage.getItem(STORAGE_KEY) || "[]");
    todos.forEach(function(todo, index) {
      todo.id = index;
    });
    todoStorage.uid = todos.length;
    return todos;
  },
  save: function(todos) {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(todos));
  }
};

// visibility filters
var filters = {
  all: function(todos) {
    return todos;
  },
  active: function(todos) {
    return todos.filter(function(todo) {
      return !todo.completed;
    });
  },
  completed: function(todos) {
    return todos.filter(function(todo) {
      return todo.completed;
    });
  }
};

// vue component instance
export default {
  // app initial state
  data() {
    return {
      todos: todoStorage.fetch(),
      newTodo: "",
      editedTodo: null,
      visibility: "all"
    };
  },

  // watch todos change for localStorage persistence
  watch: {
    todos: {
      handler: function(todos) {
        todoStorage.save(todos);
      },
      deep: true
    }
  },

  // computed properties
  // http://vuejs.org/guide/computed.html
  computed: {
    filteredTodos: function() {
      return filters[this.visibility](this.todos);
    },
    remaining: function() {
      return filters.active(this.todos).length;
    },
    allDone: {
      get: function() {
        return this.remaining === 0;
      },
      set: function(value) {
        this.todos.forEach(function(todo) {
          todo.completed = value;
        });
      }
    }
  },

  filters: {
    pluralize: function(n) {
      return n === 1 ? "item" : "items";
    }
  },

  // methods that implement data logic.
  // note there's no DOM manipulation here at all.
  methods: {
    addTodo: function() {
      var value = this.newTodo && this.newTodo.trim();
      if (!value) {
        return;
      }
      this.todos.push({
        id: todoStorage.uid++,
        title: value,
        completed: false
      });
      this.newTodo = "";
    },

    removeTodo: function(todo) {
      this.todos.splice(this.todos.indexOf(todo), 1);
    },

    editTodo: function(todo) {
      this.beforeEditCache = todo.title;
      this.editedTodo = todo;
    },

    doneEdit: function(todo) {
      if (!this.editedTodo) {
        return;
      }
      this.editedTodo = null;
      todo.title = todo.title.trim();
      if (!todo.title) {
        this.removeTodo(todo);
      }
    },

    cancelEdit: function(todo) {
      this.editedTodo = null;
      todo.title = this.beforeEditCache;
    },

    onFilterChange: function(visibility) {
      if (filters[visibility]) {
        this.visibility = visibility;
      } else {
        this.visibility = "all";
      }
    },

    removeCompleted: function() {
      this.todos = filters.active(this.todos);
    }
  }
};
</script>

<style scoped>
[v-cloak] {
  display: none;
}
.strike {
  text-decoration: line-through;
}
</style>
